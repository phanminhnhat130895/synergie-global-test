import { createSlice, PayloadAction } from "@reduxjs/toolkit"
import { FlashCard } from "../models/flashCard"

type FlashCardState = {
    flashCards: FlashCard[],
    flashCardCount: number
}

const initialState: FlashCardState = {
    flashCards: [],
    flashCardCount: 0
}

const flashCardSlice = createSlice({
    name: 'flashCardSlice',
    initialState,
    reducers: {
        setFlashCards: (state: FlashCardState, action: PayloadAction<FlashCard[]>) => {
            state.flashCards = action.payload;
        },
        setFlashCardCount: (state: FlashCardState, action: PayloadAction<number>) => {
            state.flashCardCount = action.payload;
        },
        addFlashCard: (state: FlashCardState, action: PayloadAction<FlashCard>) => {
            state.flashCards = [...state.flashCards, action.payload];
            state.flashCardCount = state.flashCardCount + 1;
        },
        removeFlashCard: (state: FlashCardState, action: PayloadAction<string>) => {
            state.flashCards = [...state.flashCards.filter(x => x.id != action.payload)];
            state.flashCardCount = state.flashCardCount - 1;
        }
    }
})

export const { setFlashCards, setFlashCardCount, addFlashCard, removeFlashCard } = flashCardSlice.actions;

export default flashCardSlice.reducer;