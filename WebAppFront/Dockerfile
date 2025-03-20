# Usa una imagen de Node.js para construir el frontend
FROM node:18 AS build
WORKDIR /app

# Copiar archivos y dependencias
COPY package.json package-lock.json ./
RUN npm install

# Copiar el resto del código fuente
COPY . ./

# Construir la aplicación
RUN npm run build

# Imagen final con Nginx para servir el frontend
FROM nginx:alpine
COPY --from=build /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
