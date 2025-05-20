import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    crops: [],
    selected:{},
    page: 1,
    totalCount: 0,
    limit: 10
};

const cropsSlice = createSlice({
    name: "crops",
    initialState,
    reducers: {
    setCrops: (state, action) => {
        state.crops = action.payload;
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

export const { setCrops, setSelected, setPage, setTotalCount, setLimit } = cropsSlice.actions;
export default cropsSlice.reducer;
