const BASE_URL = "https://localhost:7142/api/medicines";
const AUTH_BASE_URL = "https://localhost:7142/api";

export const getMedicines = async (search = "") => {
    const response = await fetch(`${BASE_URL}?search=${search}`);
    return response.json();
};

export const addMedicine = async (medicine) => {
    const response = await fetch(BASE_URL, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(medicine)
    });
    return response.json();
};

export const registerUser = async (data) =>{
    const response = await fetch(`${AUTH_BASE_URL}/register`,{
        method: "POST",
        headers: {"Content-Type":"application/json" },
        body: JSON.stringify(data)
    });

    if(!response.ok)
        throw new Error("Registration Failed");
    
    return response.json();
}

export const loginUser = async (data) =>{
    const  response = await fetch(`${AUTH_BASE_URL}/login`,{
        method: "POST",
        headers: {"Content-Type":"application/json"},
        body: JSON.stringify(data)
    });

    if(!response.ok)
        throw new Error("Invalid Credentials");

    return response.json();
}