import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  equipment: [],
  selected:{},
  page: 1,
  totalCount: 0,
  limit: 10
};

const equipmentSlice = createSlice({
  name: "equipment",
  initialState,
  reducers: {
    setEquipment: (state, action) => {
      state.equipment = action.payload;
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

export const { setEquipment, setSelected, setPage, setTotalCount, setLimit } = equipmentSlice.actions;
export default equipmentSlice.reducer;
