import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  name: '',
};

const pageSlice = createSlice({
  name: "page",
  initialState,
  reducers: {
    setName: (state, action) => {
      state.name = action.payload;
    }
  },
});

export const { setName } = pageSlice.actions;
export default pageSlice.reducer;
