import { configureStore } from "@reduxjs/toolkit"
import animalsReducer from "./animalsSlice"
import pasturesReducer from "./pasturesSlice"
import cropsReducer from "./cropsSlice"
import fieldsReducer from "./fieldsSlice"
import employeesReducer from "./employeesSlice"
import pageReducer from "./pageSlice"

const store = configureStore({
  reducer: {
    animals: animalsReducer,
    pastures: pasturesReducer,
    crops: cropsReducer,
    fields: fieldsReducer,
    employees: employeesReducer,
    page: pageReducer
  },
});

export default store;
