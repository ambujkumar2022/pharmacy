import React, { createContext, useState } from 'react';
export const GlobalStateContext = createContext();

export const GlobalStateProvider = ({ children }) => {
    const [user, setUser] = useState(null);
    const [isAuthenticated, setIsAuthenticated] = useState(false);

    return (
        <GlobalStateContext.Provider value={{ user, setUser, isAuthenticated, setIsAuthenticated }}>
            {children}
        </GlobalStateContext.Provider>
    );
};  