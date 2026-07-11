import React, { useState } from "react";
import { addMedicine } from "../api";
import "./AddMedicine.css";

const AddMedicine = ({ onAdd }) => {
    const [form, setForm] = useState({
        name: "",
        expiryDate: "",
        quantity: "",
        price: "",
        brand: "",
        notes: ""
    });

    const handleChange = (e) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        await addMedicine(form);
        onAdd(); // refresh list
    };

    return (
        <form onSubmit={handleSubmit}>
            <h2>Add Medicine</h2>

            <input name="name" placeholder="Name" onChange={handleChange} required />
            <input type="date" name="expiryDate" onChange={handleChange} required />
            <input type="number" name="quantity" placeholder="Quantity" onChange={handleChange} required />
            <input type="number" step="0.01" name="price" placeholder="Price" onChange={handleChange} required />
            <input name="brand" placeholder="Brand" onChange={handleChange} required />
            <textarea name="notes" placeholder="Notes" onChange={handleChange}></textarea>

            <button type="submit">Add</button>
        </form>
    );
};

export default AddMedicine;