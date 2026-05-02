import React, {useState} from "react";
import MedicineList from "./Components/MedicineList";
import AddMedicine from "./Components/AddMedicine";

function App() {
  //const listRef = useRef();   --It will not work unless used 'forwardRef+UseImperativeHandle'
  //Use state+props instead.
  const [reloadFlag, setreloadFlag] = useState(false);

  const reloadMedicines = () =>
  {
    setreloadFlag(prev =>!prev);
  };

  return (
      <div>
         <AddMedicine onAdd={reloadMedicines}/>
         <MedicineList reload={reloadFlag}/>
      </div>
  );
}

export default App;
