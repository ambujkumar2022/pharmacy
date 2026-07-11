import React, { useContext, useMemo } from "react";
import { GlobalContext } from "./GlobalState";

function DoubleDisplay() {
  const { globalNum } = useContext(GlobalContext);

  const doubled = useMemo(() => globalNum * 2, [globalNum]);

  return (
    <div>
      {globalNum !== 0 ? (
        <p>Double of {globalNum} is {doubled}</p>
      ) : (
        <p>Please enter a number above.</p>
      )}
    </div>
  );
}

export default DoubleDisplay;
