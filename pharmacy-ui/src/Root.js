import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from "./Components/Login";
import Register from "./Components/Register";
import App from "./App";

const Root = () =>{
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element = {<Login/>} />
                <Route path = "/register" element = {<Register/>} />
                <Route path = "/dabatboard" element = {<App/>} />
            </Routes>
        </BrowserRouter>
    )
}

export default Root;