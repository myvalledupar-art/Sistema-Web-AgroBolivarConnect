const API = "http://localhost:5071/api";
console.log("Conectado a", API);

async function cargarAgricultores(){
  try {
    const res = await fetch(`${API}/Agricultores`);
    const data = await res.json();
    const tbody = document.getElementById("tabla") || document.getElementById("tablaAgricultores");
    if(tbody) tbody.innerHTML = data.map(a=>`<tr><td>${a.idAgricultor || a.id}</td><td>${a.nombre}</td><td>${a.municipio || ''}</td></tr>`).join("") || "<tr><td colspan=3>No hay datos</td></tr>";
  } catch(e){ console.log(e) }
}

async function cargarProductos(){
  try {
    const res = await fetch(`${API}/Productos`);
    const data = await res.json();
    const tbody = document.getElementById("tablaProductos");
    if(tbody) tbody.innerHTML = data.map(p=>`<tr><td>${p.idProducto || p.id}</td><td>${p.nombre}</td><td>$${p.precio}</td><td>${p.stock || p.cantidad}</td><td>${p.idAgricultor || ''}</td></tr>`).join("");
  } catch(e){ console.log(e) }
}

async function cargarCompradores(){
  try {
    const res = await fetch(`${API}/Compradores`);
    const data = await res.json();
    const tbody = document.getElementById("tablaCompradores");
    if(tbody) tbody.innerHTML = data.map(c=>`<tr><td>${c.idComprador || c.id}</td><td>${c.nombre}</td><td>${c.empresa || ''}</td><td>${c.telefono || ''}</td></tr>`).join("");
  } catch(e){ console.log(e) }
}

// Auto detecta en qué página estás
if(document.getElementById("tabla") || document.getElementById("tablaAgricultores")) cargarAgricultores();
if(document.getElementById("tablaProductos")) cargarProductos();
if(document.getElementById("tablaCompradores")) cargarCompradores();