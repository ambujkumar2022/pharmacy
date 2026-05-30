const log = (level, message, data) => {
    if(process.env.NODE_ENV === "development") 
    {
        console[level](`[${level}] ${message}`, data || "");
    }
    

    //Send logs to Backend
    await fetch("/api/logs", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"},
        body: JSON.stringify({ level, message, data }),
    });
};

export default log;
