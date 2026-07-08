import React, { useEffect, useState } from 'react';
import { createRoot } from 'react-dom/client';
import axios from 'axios';
import './styles.css';

type Product = { id:number; name:string; category:string; price:number; stock:number };

function App() {
  const [products, setProducts] = useState<Product[]>([]);
  const [search, setSearch] = useState('');
  const [cart, setCart] = useState<Product[]>([]);

  useEffect(() => { loadProducts(); }, []);

  async function loadProducts() {
    const res = await axios.get(`/products/api/products?search=${search}`);
    setProducts(res.data.items ?? []);
  }

  return <main>
    <h1>E-Commerce Microservices</h1>
    <p>React + .NET 8 + API Gateway + SQL + Redis + RabbitMQ</p>
    <section className="toolbar">
      <input placeholder="Search products" value={search} onChange={e => setSearch(e.target.value)} />
      <button onClick={loadProducts}>Search</button>
    </section>
    <section className="grid">
      {products.map(p => <article className="card" key={p.id}>
        <h3>{p.name}</h3>
        <p>{p.category}</p>
        <strong>₹{p.price}</strong>
        <button onClick={() => setCart([...cart, p])}>Add to Cart</button>
      </article>)}
    </section>
    <h2>Cart Items: {cart.length}</h2>
  </main>;
}

createRoot(document.getElementById('root')!).render(<App />);
