import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    fields: [],
    selected:{},
    page: 1,
    totalCount: 0,
    limit: 4
};

const fieldsSlice = createSlice({
    name: "fields",
    initialState,
    reducers: {
    setFields: (state, action) => {
        state.fields = action.payload;
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

export const { setFields, setSelected, setPage, setTotalCount, setLimit } = fieldsSlice.actions;
export default fieldsSlice.reducer;
