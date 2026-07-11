import { render, screen } from "@testing-library/react";
import App from "../App";

test("renders React Concepts Demo heading", () => {
  render(<App />);
  const heading = screen.getByText(/React Concepts Demo/i);
  expect(heading).toBeInTheDocument();
});

test("renders API loading text", () => {
  render(<App />);
  const loading = screen.getByText(/Loading.../i);
  expect(loading).toBeInTheDocument();
});
