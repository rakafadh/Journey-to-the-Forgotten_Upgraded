# **Command Line RPG Game**  
### **Kelompok 6**

Selamat datang di proyek **Command Line RPG Game**! Game ini adalah permainan RPG berbasis teks yang dikembangkan oleh **Kelompok 6**. Proyek ini dibuat dengan menggunakan **.NET Core** untuk menjalankan aplikasi berbasis console.  

---

## **Fitur Utama**
- Pilihan karakter dengan atribut unik seperti **Health**, **Strength**, dan **Defense**.  
- Sistem pertarungan melawan musuh seperti **Dragon**, **Goblin**, dan **Skeleton**.  
- Inventaris untuk mengelola item seperti senjata dan perisai.  
- Strategi bertarung dinamis yang dapat disesuaikan.  

---

## **Persyaratan**
- **.NET SDK** versi 6.0 atau lebih baru.  
- Sistem operasi: Windows, macOS, atau Linux.  

---

## **Petunjuk Instalasi dan Menjalankan Program**

Ikuti langkah-langkah berikut untuk menjalankan game ini:

### **1. Buat Proyek Console Baru**
Pastikan Anda berada di direktori proyek, lalu jalankan perintah berikut untuk membuat proyek console:  
```bash
dotnet new console
```

### **2. Jalankan Game**
Setelah proyek berhasil dibuat, jalankan file **Program.cs** dengan perintah:
```bash
dotnet run
```

## **Struktur Direktori**
```
/CommandLineRPG
├── Program.cs           # File utama untuk menjalankan game.
├── Character.cs         # Definisi karakter pemain dan musuh.
├── Inventory.cs         # Sistem inventaris pemain.
├── BattleSystem.cs      # Sistem pertempuran utama.
├── Items/
│   ├── WeaponItem.cs    # Item senjata.
│   ├── DefenseItem.cs   # Item perisai.
│   └── ItemDecorator.cs # Dekorator item.
└── README.md            # File panduan proyek ini.
```

## **Gameplay**
1. **Pilih Karakter**: Pemain memilih karakter dengan atribut unik.
2. **Bertarung Melawan Musuh**: Pilih strategi untuk mengalahkan musuh.
3. **Kelola Inventory**: Gunakan item untuk meningkatkan kemampuan bertarung.

## **Kontributor**
Proyek ini dikembangkan oleh:
* **Wilman Saragih Sitio (2306161776)**
* **Abednego Zebua (2306161883)**
* **Raka Arrayan Muttaqein (2306161800)**
* **Daffa Hardhan (2306161263)**
