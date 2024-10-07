namespace App.Repositories.Database;

using System;
using System.Linq;
using App.Models;
using Microsoft.EntityFrameworkCore;

public class DatabaseSeeder
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new CheckoutDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<CheckoutDbContext>>()))
        {
            if (!context.Products.Any())
            {
                Category corsair = new("Corsair") { ImageUrl = "http://localhost:5102/files/images/categories/1.png" };
                Category kingston = new("Kingston") { ImageUrl = "http://localhost:5102/files/images/categories/2.png" };
                Category logitech = new("Logitech") { ImageUrl = "http://localhost:5102/files/images/categories/3.png" };
                Category riseMode = new("Rise Mode") { ImageUrl = "http://localhost:5102/files/images/categories/4.png" };
                Category intel = new("Intel") { ImageUrl = "http://localhost:5102/files/images/categories/5.png" };
                Category kbmGaming = new("KBM! Gaming") { ImageUrl = "http://localhost:5102/files/images/categories/6.png" };

                Product gabinete1 = new("Gabinete Gamer Corsair 3000D RGB Airflow, Mid-Tower, ATX, Lateral em Vidro Temperado, com FAN, Branco - CC-9011256-WW", corsair, 100, 419.9) { ImageUrl = "http://localhost:5102/files/images/products/2.png" };
                Product gabinete2 = new("Gabinete Gamer Corsair 7000D Airflow, Full Tower, Lateral em Vidro Temperado, Branco - CC-9011219-WW", corsair, 100, 979.9) { ImageUrl = "http://localhost:5102/files/images/products/3.png" };


                Product memoriaRam1 = new("Memória RAM Kingston Fury Beast, 8GB, 3200MHz, DDR4, CL16, Preto - KF432C16BB/8", kingston, 300, 174.99) { ImageUrl = "http://localhost:5102/files/images/products/6.png" };
                Product memoriaRam2 = new("Memória RAM Kingston Fury Beast, 16GB, 3200MHz, DDR4, CL16, Preto - KF432C16BB1/16", kingston, 160, 289.99) { ImageUrl = "http://localhost:5102/files/images/products/8.png" };

                Product headset = new("Headset Gamer Rise Mode G1, Drivers 50mm, P2, Preto - RM-HS-G1-FB", riseMode, 350, 139.9) { ImageUrl = "http://localhost:5102/files/images/products/14.png" };
                Product monitor = new("Monitor Gamer Rise Mode 27'' Full HD, 165hz, IPS, Preto, DisplayPort e HDMI, sRGB 99 %, Suporte Vesa - RM - MOG - 27F165FH - B", riseMode, 100, 899.99) { ImageUrl = "http://localhost:5102/files/images/products/15.png" };

                Product tecladoKbm1 = new("Teclado Mecânico Gamer KBM! GAMING TG700, Preto, 65% e ABNT2, RGB, Switch Gateron Red - KGTG700PTVR", kbmGaming, 100, 259.99) { ImageUrl = "http://localhost:5102/files/images/products/20.png" };
                Product tecladokbm2 = new("Teclado Mecânico Gamer KBM! GAMING TG700, Branco, 65% e ABNT2, RGB, Switch Gateron Red - KGTG700BRVR", kbmGaming, 100, 259.99) { ImageUrl = "http://localhost:5102/files/images/products/21.png" };

                context.Products.AddRange(
                    new Product("Gabinete Gamer Corsair iCUE 4000X, RGB, Mid-Tower, ATX, Lateral e Frontal em Vidro Temperado, Com FAN, Branco - CC-9011205-WW", corsair, 100, 999.99) { ImageUrl = "http://localhost:5102/files/images/products/1.png" },
                    gabinete1,
                    gabinete2,
                    new Product("Mouse Gamer Corsair Katar PRO Ultra-Leve, RGB, 6 Botões, 12400DPI, Preto - CH-930C011-NA", corsair, 200, 198.85) { ImageUrl = "http://localhost:5102/files/images/products/4.png" },
                    new Product("Monitor Gamer Acer Nitro 23.8", corsair, 75, 7599.99) { ImageUrl = "http://localhost:5102/files/images/products/5.png" },
                    memoriaRam1,
                    new Product("SSD 500GB Kingston Fury Renegade, com Dissipador, PCIe 4.0 NVMe M.2, Gen4x4, Leitura: 7300MB/s e Gravação: 3900MB/s, Preto, compatível com o PlayStation 5 - SFYRSK/500G", kingston, 250, 599.99) { ImageUrl = "http://localhost:5102/files/images/products/7.png" },
                    memoriaRam2,
                    new Product("SSD 1 TB Kingston Fury Renegade, M.2 2280 PCIe, NVMe, Leitura: 7300MB/s e Gravação: 6000MB/s, Preto - SFYRS/1000G", kingston, 100, 759.99) { ImageUrl = "http://localhost:5102/files/images/products/9.png" },
                    new Product("Teclado Sem Fio Logitech Wave Keys, Bluetooth, Layout US, Com Design Ondulado, Ergonômico, Grafite - 920-012281", logitech, 70, 359.99) { ImageUrl = "http://localhost:5102/files/images/products/10.png" },
                    new Product("Teclado Sem Fio Logitech Keys-To-Go 2, Bluetooth, para Tablets, iPad, macOs, Windows, Capa Integrada, Grafite - 920-012867", logitech, 80, 509.99) { ImageUrl = "http://localhost:5102/files/images/products/11.png" },
                    new Product("Teclado Sem Fio Logitech Wave Keys, Bluetooth, Layout US, Com Design Ondulado, Ergonômico, Branco - 920-012282", logitech, 80, 338.99) { ImageUrl = "http://localhost:5102/files/images/products/12.png" },
                    new Product("Mouse Sem Fio Logitech Pebble 2 M350s, USB Logi Bolt ou Bluetooth e Pilha Inclusa, com Clique Silencioso, Grafite - 910-007049", logitech, 200, 109.99) { ImageUrl = "http://localhost:5102/files/images/products/13.png" },
                    headset,
                    monitor,
                    new Product("Mesa Gamer RGB Rise Mode Desk 06, Suporte para Copos, Suporte para Headset, Preto - RM-TB-06-BK", riseMode, 80, 849.9) { ImageUrl = "http://localhost:5102/files/images/products/16.png" },
                    new Product("Computador Fácil Intel Core i5-650, 8GB DDR3, SSD 240GB, 350W, Linux - 18000", intel, 50, 1319.99) { ImageUrl = "http://localhost:5102/files/images/products/17.png" },
                    new Product("Notebook Gamer Acer Nitro V15 Intel Core i5-13420H, 8GB RAM, GeForce RTX 3050, SSD 512GB, 15.6'' FHD IPS 144Hz, Windows 11, Preto - ANV15 - 51 - 58AZ", intel, 30, 4999.99) { ImageUrl = "http://localhost:5102/files/images/products/18.png" },
                    new Product("Processador Intel Core i5-12400F, 2.5GHz (4.4GHz Max Turbo), Cache 18MB, LGA 1700 - BX8071512400F", intel, 20, 669.99) { ImageUrl = "http://localhost:5102/files/images/products/19.png" },
                    tecladoKbm1,
                    tecladokbm2
                );

                context.Campaigns.AddRange(
                    new Campaign("Ofertas do dia", true) { ImageUrl = "http://localhost:5102/files/images/campaigns/1.png", Products = [gabinete1, gabinete2, headset, monitor] },
                    new Campaign("Teclado mecânico", true) { ImageUrl = "http://localhost:5102/files/images/campaigns/2.png", Products = [tecladoKbm1, tecladokbm2] },
                    new Campaign("Memórias Ram", true) { ImageUrl = "http://localhost:5102/files/images/campaigns/3.png", Products = [memoriaRam1, memoriaRam2] }
                );
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User("Admin", "admin@email.com", "password", Enums.ERole.ADMIN)
                );
            }

            context.SaveChanges();
        }
    }
}
