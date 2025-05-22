import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  employees: [],
  selected:{},
  page: 1,
  totalCount: 0,
  limit: 10
};

const employeesSlice = createSlice({
  name: "employees",
  initialState,
  reducers: {
    setEmployees: (state, action) => {
      state.employees = action.payload;
    },
    setSelected: (state, action) => {
      state.selected = action.payload;
    },
    setPage: (state, action) => {
      state.page = action.payload;
    },
    setTotalCount: (state, action) => {
      state.totalCount = action.payload;
    },
    setLimit: (state, action) => {
      state.limit = action.payload;
    }
  },
});

export const { setEmployees, setSelected, setPage, setTotalCount, setLimit } = employeesSlice.actions;
export default employeesSlice.reducer;
