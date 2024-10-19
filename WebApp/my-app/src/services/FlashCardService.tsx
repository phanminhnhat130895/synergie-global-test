import axios from "axios";
import { handleError } from "../common/helper/ErrorHandler";
import { CreateFlashCardResponse } from "../models/createFlashCardResponse";
import { GetFlashCardsResponse } from "../models/getFlashCardsResponse";
import { DeleteFlashCardResponse } from "../models/deleteFlashCardResponse";

const api = "http://localhost:5167/api/";

export const getFlashCardsAPI = async (page: number, pageSize: number) => {
    try {
        const data = await axios.get<GetFlashCardsResponse>(api + `flashcard?page=${page}&pageSize=${pageSize}`);
        return data;
    } catch (error) {
        handleError(error);
    }
}

export const createFlashCard = async (content: string, meaning: string) => {
    try {
        const data = await axios.post<CreateFlashCardResponse>(api + "flashcard", {
          content: content,
          meaning: meaning,
        });
        return data;
    } catch (error) {
        handleError(error);
    }
}

export const deleteFlashCard = async (cardId: string) => {
    try {
        const data = await axios.delete<DeleteFlashCardResponse>(api + `flashcard?cardId=${cardId}`);
        return data;
    } catch (error) {
        handleError(error);
    }
}