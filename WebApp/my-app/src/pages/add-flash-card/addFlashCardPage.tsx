import { useState } from "react";
import { createFlashCard } from "../../services/FlashCardService";
import { toast } from "react-toastify";
import { useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../../store/store";
import { addFlashCard } from "../../store/flashCardSlice";
import FlashCardComponent from '../../components/flashCard';
import './addFlashCardPage.css';

const AddFlashCardPage = () => {
    const flashCards = useSelector((state: RootState) => state.flashCard.flashCards);
    const flashCardCount = useSelector((state: RootState) => state.flashCard.flashCardCount);
    const [content, setContent] = useState('');
    const [meaning, setMeaning] = useState('');
    const navigate = useNavigate();
    const dispatch = useDispatch();

    const add = async () => {
        if (!content || !meaning) {
            toast.error("Content or meaning is empty.");
            return;
        }

        const response = await createFlashCard(content, meaning);
        if (response) {
            dispatch(addFlashCard(response.data.flashCard));
            toast.info("Add Flash Card Successful");
        }
    }

    const goToStudyMode = () => {
        navigate("/");
    }

    return (
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
    )
}

export default AddFlashCardPage;