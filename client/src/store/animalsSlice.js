import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  animals: [],
  selected:{},
  page: 1,
  totalCount: 0,
  limit: 10
};

const animalsSlice = createSlice({
  name: "animals",
  initialState,
  reducers: {
    setAnimals: (state, action) => {
      state.animals = action.payload;
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

export const { setAnimals, setSelected, setPage, setTotalCount, setLimit } = animalsSlice.actions;
export default animalsSlice.reducer;
