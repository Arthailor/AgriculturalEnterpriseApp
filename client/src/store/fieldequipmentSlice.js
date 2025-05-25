import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  fieldequipment: []
};

const fieldequipmentSlice = createSlice({
  name: "fieldequipment",
  initialState,
  reducers: {
    setFieldequipment: (state, action) => {
      state.fieldequipment = action.payload;
    }
  },
});

export const { setFieldequipment } = fieldequipmentSlice.actions;
export default fieldequipmentSlice.reducer;
