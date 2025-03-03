import React from "react";

const Homepage = () => {
  const [data, setData] = React.useState(null);

  React.useEffect(() => {
    fetch("/api/WeatherForecast")
      .then((res) => res.json())
      .then((data) => setData(data));
  }, []);

  return (
    <div>
      <h1>iLM Machine - Spreading the Deen</h1>
      <p>{data}</p>
    </div>
  );
};

export default Homepage;
