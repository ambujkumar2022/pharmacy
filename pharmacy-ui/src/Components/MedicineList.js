import React, { useEffect, useState } from "react";
import { getMedicines } from "../api";
import "./MedicineList.css";

const MedicineList = (props) => {
    const [medicines, setMedicines] = useState([]);
    const [search, setSearch] = useState("");

    useEffect(() => {
        loadMedicines();
    }, [props.reload]);

    const loadMedicines = async () => {
        const data = await getMedicines(search);
        setMedicines(data);
    };

    const getRowStyle = (med) => {
        if (!med.expiryDate) return {};

        const expiry = new Date(med.expiryDate);
        const today = new Date();

        // Normalize both dates (ignore time)
        expiry.setHours(0, 0, 0, 0);
        today.setHours(0, 0, 0, 0);
        const diffDays = (expiry - today) / (1000 * 60 * 60 * 24);

        
       if (diffDays < 0) return { backgroundColor: "red" };       // expired
       if (diffDays <= 30) return { backgroundColor: "orange" };  // near expiry
        if (med.quantity < 10) return { backgroundColor: "yellow" };
        return {};
    };

    return (
        <div>
            <h2>Medicine List</h2>

            <input
                type="text"
                placeholder="Search medicine..."
                value={search}
                onChange={(e) => setSearch(e.target.value)}
            />
            <button onClick={loadMedicines}>Search</button>

            <table border="1">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Expiry</th>
                        <th>Quantity</th>
                        <th>Price</th>
                        <th>Brand</th>
                    </tr>
                </thead>
                <tbody>
                    {medicines.map((med) => (
                        <tr key={med.id} style={getRowStyle(med)}>
                            <td>{med.name}</td>
                            <td>{med.expiryDate.split("T")[0]}</td>
                            <td>{med.quantity}</td>
                            <td>{med.price}</td>
                            <td>{med.brand}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default MedicineList;