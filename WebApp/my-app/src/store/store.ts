import { configureStore } from "@reduxjs/toolkit";
import flashCardReducer from './flashCardSlice';

const store = configureStore({
    reducer: {
        flashCard: flashCardReducer,
    },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export default store;