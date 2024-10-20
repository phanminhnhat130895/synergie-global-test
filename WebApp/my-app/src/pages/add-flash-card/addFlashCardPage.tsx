import { useEffect, useState } from "react";
import { createFlashCard, getFlashCardsAPI } from "../../services/FlashCardService";
import { toast } from "react-toastify";
import { useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../../store/store";
import { addFlashCard, setFlashCardCount, setFlashCards } from "../../store/flashCardSlice";
import FlashCardComponent from '../../components/flashCard/flashCard';
import './addFlashCardPage.css';
import { TopBarComponent } from "../../components/topBar/topBar";

const AddFlashCardPage = () => {
    const flashCards = useSelector((state: RootState) => state.flashCard.flashCards);
    const flashCardCount = useSelector((state: RootState) => state.flashCard.flashCardCount);
    const [content, setContent] = useState('');
    const [meaning, setMeaning] = useState('');
    const navigate = useNavigate();
    const dispatch = useDispatch();

    useEffect(() => {
        const fetchData = async () => {
            const response = await getFlashCardsAPI(0, 99999);
            if (response) {
                dispatch(setFlashCards(response.data.flashCards));
                dispatch(setFlashCardCount(response.data.flashCardCount));
            }
        }
        
        fetchData();
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    const add = async () => {
        if (!content || !meaning) {
            toast.error("Content or meaning is empty.");
            return;
        }

        const response = await createFlashCard(content, meaning);
        if (response) {
            dispatch(addFlashCard(response.data.flashCard));
            toast.info("Add Flash Card Successful.");
            setContent('');
            setMeaning('');
        }
    }

    const goToStudyMode = () => {
        navigate("/");
    }

    return (
        <>
            <TopBarComponent />
            <div className="page">
                <div className="manage-section add-flash-card-top">
                    <button className="button-control navigate-button study-mode-btn" onClick={goToStudyMode}>Study Mode</button>
                    <span className="total-card">Total Cards: {flashCardCount}</span>
                </div>
                <input className="input-control" name="content" placeholder="Enter word or phrase" type="text" 
                    value={content} onChange={(e) => setContent(e.target.value)} />
                <input className="input-control" name="meaning" placeholder="Enter meaning" type="text" 
                    value={meaning} onChange={(e) => setMeaning(e.target.value)} />
                <button className="button-control primary-button" onClick={add}>Add Flash Card</button>
                <div className="card-area">
                    {
                        flashCards.map(flashCard => (
                            <FlashCardComponent flashCard={flashCard} key={flashCard.id} />
                        ))
                    }
                </div>
            </div>
        </>
    )
}

export default AddFlashCardPage;