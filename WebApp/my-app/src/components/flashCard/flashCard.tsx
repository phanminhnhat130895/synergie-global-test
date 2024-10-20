import { useDispatch } from "react-redux";
import { FlashCard } from "../../models/flashCard";
import { deleteFlashCard } from "../../services/FlashCardService";
import { removeFlashCard } from "../../store/flashCardSlice";
import './flashCard.css';

type FlashCardProps = {
    flashCard: FlashCard
}

const FlashCardComponent = (props: FlashCardProps) => {
    const dispatch = useDispatch();

    const deleteCard = async () => {
        const response = await deleteFlashCard(props.flashCard.id);
        if (response) {
            dispatch(removeFlashCard(response.data.cardId));
        }
    }

    return (
        <div className="card-container">
            <div className="content">
                <div className="content-item">{props.flashCard.content}</div>
                <div className="content-meaning">{props.flashCard.meaning}</div>
            </div>
            <div className="button-area">
                <button className="no-outline-button delete-button" onClick={deleteCard}>delete</button>
            </div>
        </div>
    )
}

export default FlashCardComponent;