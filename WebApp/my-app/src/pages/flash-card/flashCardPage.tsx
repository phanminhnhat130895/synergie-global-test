import { useEffect, useState } from "react";
import { FlashCard } from "../../models/flashCard";
import { getFlashCardsAPI } from "../../services/FlashCardService";
import { useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../../store/store";
import { setFlashCardCount, setFlashCards } from "../../store/flashCardSlice";
import './flashCardPage.css';
import { TopBarComponent } from "../../components/topBar/topBar";

const FlashCardPage = () => {
    const flashCards = useSelector((state: RootState) => state.flashCard.flashCards);
    const flashCardCount = useSelector((state: RootState) => state.flashCard.flashCardCount);
    const [currentFlashCard, setCurrentFlashCard] = useState<FlashCard | null>(null);
    const [currentIndex, setCurrentIndex] = useState(0);
    const [isLoading, setIsLoading] = useState(false);
    const [isShowMeaning, setIsShowMeaning] = useState(false);
    const navigate = useNavigate();
    const dispatch = useDispatch();

    useEffect(() => {
        const fetchData = async () => {
            const response = await getFlashCardsAPI(0, 99999);
            if (response) {
                dispatch(setFlashCards(response.data.flashCards));
                dispatch(setFlashCardCount(response.data.flashCardCount));
                if (response.data.flashCards.length > 0) {
                    setCurrentFlashCard(response.data.flashCards[currentIndex]);
                }
            }
            setIsLoading(false);
        }
        
        fetchData();
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    const showMeaning = () => {
        setIsShowMeaning(prev => !prev);
    }

    const showPrev = () => {
        setCurrentIndex(prev => {
            const value = prev - 1;
            if (value >= 0) {
                setCurrentFlashCard(flashCards[value]);
                return value;
            }
            return prev;
        })
    }

    const showNext = () => {
        setCurrentIndex(prev => {
            const value = prev + 1;
            if (value < flashCardCount) {
                setCurrentFlashCard(flashCards[value]);
                return value;
            }
            return prev;
        })
    }

    const goToAddCard = () => {
        navigate("add-flash-card");
    }

    return (
        <>
            {
                isLoading ? 
                <div>Loading...</div> :
                <>
                    <TopBarComponent />
                    <div className="page">
                        <div className="manage-section">
                            <button className="button-control navigate-button manage-card-btn" onClick={goToAddCard}>Manage Cards</button>
                        </div>
                        <div className="card">
                            <div className="card-content">{currentFlashCard?.content}</div>
                            {isShowMeaning && <div className="card-meaning">{currentFlashCard?.meaning}</div>}
                        </div>
                        <div>
                            <button className="button-control prev-button" onClick={showPrev} disabled={currentIndex === 0}>&lt;</button>
                            <button className="button-control primary-button meaning-button" onClick={showMeaning} disabled={flashCardCount === 0}>
                                {isShowMeaning ? 'Hide Meaning' : 'Show Meaning'}
                            </button>
                            <button className="button-control next-button" onClick={showNext} disabled={currentIndex === flashCardCount - 1 || flashCardCount === 0}>
                                &gt;
                            </button>
                        </div>
                        <p>Card {flashCardCount > 0 ? currentIndex + 1 : 0} of {flashCardCount}</p>
                    </div>
                </>
            }
        </>
        
    )
}

export default FlashCardPage;