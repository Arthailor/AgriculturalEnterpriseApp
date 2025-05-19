import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  pastures: [],
  selected:{},
  page: 1,
  totalCount: 0,
  limit: 1
};

const pasturesSlice = createSlice({
  name: "pastures",
  initialState,
  reducers: {
    setPastures: (state, action) => {
      state.pastures = action.payload;
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

export const { setPastures, setSelected, setPage, setTotalCount, setLimit } = pasturesSlice.actions;
export default pasturesSlice.reducer;
