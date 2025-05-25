import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  repairs: [],
  selected:{},
  selectedEquipment:{},
  page: 1,
  totalCount: 0,
  limit: 10
};

const repairsSlice = createSlice({
  name: "repairs",
  initialState,
  reducers: {
    setRepairs: (state, action) => {
      state.repairs = action.payload;
    },
    setSelected: (state, action) => {
      state.selected = action.payload;
    },
    setSelectedEquipment: (state, action) => {
      state.selectedEquipment = action.payload;
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

export const { setRepairs, setSelected, setSelectedEquipment, setPage, setTotalCount, setLimit } = repairsSlice.actions;
export default repairsSlice.reducer;
