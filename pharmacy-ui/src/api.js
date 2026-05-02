const BASE_URL = "https://localhost:7142/api/medicines";

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