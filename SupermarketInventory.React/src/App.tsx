import { useEffect, useState } from 'react';
import type { Producto } from './producto';
import Loading from './Loading';
import ErrorApi from './ErrorApi';
import Products from './Products';

function App()
{
  const [products, setProducts] = useState<Producto[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect( () => {
    const fetchProducts = async() =>
    {
      try
      {
        const response = await fetch(`${import.meta.env.VITE_API_URL}/products`);

        if (!response.ok)
          throw new Error('Error al conectar con la api');

        setProducts(await response.json());
        
      }
      catch (error)
      {
        console.log(error);
        setError("Fallo la conexión al hacer fetch de los productos");
      }
      finally
      {
        setLoading(false);
      }
      
    }

    fetchProducts();
  }, [])

  if (loading)
    return <Loading />

  if (error)
    return <ErrorApi error={error}/>
  
  if (products)
    return <Products products={products} />
}

export default App