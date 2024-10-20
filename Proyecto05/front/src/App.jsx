import { useState, useEffect } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
//import './App.css'

function App() {
    const [ventas, setVentas] = useState([]);

    useEffect(() => {
        const obtieneDatos = async () => {
            let res = await fetch('https://localhost:7224/api/VentaServicios');

            let data = await res.json();
            console.log(data);
            setVentas(data);
        };

        obtieneDatos().catch(console.error);
    }, []);

    return (
        <ul>
            {ventas.map((venta) => {
                return (
                    <li>
                        {JSON.stringify(venta)}
                    </li>
                );
            })}
        </ul>
    );
}

export default App
