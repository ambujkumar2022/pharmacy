import React, {useContext} from "react";
import { GlobalStateContext } from "./GlobalStateManager";

function NumberInput({ value, onChange }) {
  const [globalNum, setglobalNum] = useContext(GlobalStateContext);

  return (
    <input
      type="number" 
      value={globalNum}
      onChange={(e) => setglobalNum(Number(e.target.value))}
    />
  );
}