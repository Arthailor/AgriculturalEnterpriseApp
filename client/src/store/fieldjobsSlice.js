import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  fieldjobs: []
};

const fieldjobsSlice = createSlice({
  name: "fieldjobs",
  initialState,
  reducers: {
    setFieldjobs: (state, action) => {
      state.fieldjobs = action.payload;
    }
  },
});

export const { setFieldjobs } = fieldjobsSlice.actions;
export default fieldjobsSlice.reducer;
