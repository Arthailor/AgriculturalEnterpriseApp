import { configureStore } from "@reduxjs/toolkit"
import animalsReducer from "./animalsSlice"
import pageReducer from "./pageSlice"

const store = configureStore({
  reducer: {
    animals: animalsReducer,
    page: pageReducer
  },
});

export default store;
