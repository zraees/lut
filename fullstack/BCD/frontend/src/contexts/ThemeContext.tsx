import { createContext, useState } from "react";

export const ThemeContext = createContext("");

export function ThemeProvider({ children }) {
  const [isDarkTheme, setIsDark] = useState(JSON.parse(localStorage.getItem("isDarkTheme")));

  const toggleTheme = (isDark) => {
    localStorage.setItem("isDarkTheme", isDark);
    setIsDark(isDark);
  };

  return (
    <ThemeContext.Provider value={{ isDarkTheme, toggleTheme }}>
      {children}
    </ThemeContext.Provider>
  );
}
