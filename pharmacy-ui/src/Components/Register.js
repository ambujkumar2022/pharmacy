import React, { useState } from "react";
import { registerUser } from "../api";

const Register = () => {
    const [form, setForm] = useState({
        username: "",
        password: ""
    });

    const handleChange = (e) => {
        setForm({
            ...form,
            [e.target.name]: e.target.value
        });
    };

    const handleRegister = async (e) => {
        e.preventDefault();

        try {
            const res = await registerUser(form);
            alert("User registered successfully");
            console.log(res);
        } catch (err) {
            alert("Registration failed");
        }
    };

    return (
        <form onSubmit={handleRegister}>
            <h2>Register</h2>

            <input
                type="text"
                name="username"
                placeholder="Enter username"
                value={form.username}
                onChange={handleChange}
                required
            />

            <input
                type="password"
                name="password"
                placeholder="Enter password"
                value={form.password}
                onChange={handleChange}
                required
            />

            <button type="submit">Register</button>
        </form>
    );
};

export default Register;