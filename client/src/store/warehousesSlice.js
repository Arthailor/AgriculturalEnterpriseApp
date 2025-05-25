import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  warehouses: [],
  selected:{},
  page: 1,
  totalCount: 0,
  limit: 10
};

const warehousesSlice = createSlice({
  name: "warehouses",
  initialState,
  reducers: {
    setWarehouses: (state, action) => {
      state.warehouses = action.payload;
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

export const { setWarehouses, setSelected, setPage, setTotalCount, setLimit } = warehousesSlice.actions;
export default warehousesSlice.reducer;
