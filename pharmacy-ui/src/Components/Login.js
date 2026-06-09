import React, { useState } from "react";
import { Link } from "react-router-dom";
import { loginUser } from "../api";

function Login() {
  const [form, setForm] = useState({
    username: "",
    password: ""
  });

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleLogin = async (e) => {
    e.preventDefault();

    try {
      const res = await loginUser(form);
      alert("Login successful");
      console.log(res.data);
    } catch {
      alert("Invalid credentials");
    }
  };

  return (
    <form onSubmit={handleLogin}>
      <input name="username" onChange={handleChange} placeholder="Username" />
      <input type="password" name="password" onChange={handleChange} placeholder="Password" />
      <button type="submit">Login</button>
      <div style={{ marginTop: "12px" }}>
        <span>New user? </span>
        <Link to="/register">Register here</Link>
      </div>
    </form>
  );
}

export default Login;