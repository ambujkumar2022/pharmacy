import React, { useState, useEffect } from "react";

function ApiData() {
  const [data, setData] = useState(null);

  useEffect(() => {
    fetch("https://jsonplaceholder.typicode.com/posts/1")
      .then((res) => res.json())
      .then((json) => setData(json))
      .catch((err) => console.error(err));
  }, []);

  return (
    <div>
      <h3>API Data:</h3>
      {data ? <p>{data.title}</p> : <p>Loading...</p>}
    </div>
  );
}

export default ApiData;
