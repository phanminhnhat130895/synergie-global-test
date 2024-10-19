import { FlashCard } from "./flashCard"

export type GetFlashCardsResponse = {
    flashCards: FlashCard[],
    flashCardCount: number
}