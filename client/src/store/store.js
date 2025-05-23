import { configureStore } from "@reduxjs/toolkit"
import animalsReducer from "./animalsSlice"
import pasturesReducer from "./pasturesSlice"
import cropsReducer from "./cropsSlice"
import fieldsReducer from "./fieldsSlice"
import employeesReducer from "./employeesSlice"
import fieldjobsReducer from "./fieldjobsSlice"
import pageReducer from "./pageSlice"

const store = configureStore({
  reducer: {
    animals: animalsReducer,
    pastures: pasturesReducer,
    crops: cropsReducer,
    fields: fieldsReducer,
    employees: employeesReducer,
    fieldjobs: fieldjobsReducer,
    page: pageReducer
  },
});

export default store;
