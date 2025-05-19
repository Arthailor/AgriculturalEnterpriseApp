import { configureStore } from "@reduxjs/toolkit"
import animalsReducer from "./animalsSlice"
import pasturesReducer from "./pasturesSlice"
import pageReducer from "./pageSlice"

const store = configureStore({
  reducer: {
    animals: animalsReducer,
    pastures: pasturesReducer,
    page: pageReducer
  },
});

export default store;
