import { defineConfig } from "vite";
import react from "@vitejs/plugin-react-swc";
import mkcert from "vite-plugin-mkcert";

// https://vite.dev/config/
export default defineConfig({
  server: {
    port: 3002,
  },
  plugins: [react(), mkcert()],
});
