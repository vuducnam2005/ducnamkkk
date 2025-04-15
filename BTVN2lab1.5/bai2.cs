using System;
using System.Collections.Generic;

abstract class Hinh
{
    // Phương thức ảo tính chu vi
    public abstract double TinhChuVi();

    // Phương thức ảo tính diện tích
    public abstract double TinhDienTich();

    // Phương thức ảo nhập thông tin hình
    public abstract void Nhap();
}

class HinhTron : Hinh
{
    private double banKinh;

    public override void Nhap()
    {
        Console.Write("Nhập bán kính hình tròn: ");
        banKinh = double.Parse(Console.ReadLine());
    }

    public override double TinhChuVi()
    {
        return 2 * Math.PI * banKinh;
    }

    public override double TinhDienTich()
    {
        return Math.PI * banKinh * banKinh;
    }

    public override string ToString()
    {
        return $"Hình tròn (bán kính = {banKinh})";
    }
}

class HinhVuong : Hinh
{
    private double canh;

    public override void Nhap()
    {
        Console.Write("Nhập cạnh hình vuông: ");
        canh = double.Parse(Console.ReadLine());
    }

    public override double TinhChuVi()
    {
        return 4 * canh;
    }

    public override double TinhDienTich()
    {
        return canh * canh;
    }

    public override string ToString()
    {
        return $"Hình vuông (cạnh = {canh})";
    }
}

class HinhTamGiac : Hinh
{
    private double canh1, canh2, canh3;

    public override void Nhap()
    {
        Console.Write("Nhập cạnh 1 tam giác: ");
        canh1 = double.Parse(Console.ReadLine());
        Console.Write("Nhập cạnh 2 tam giác: ");
        canh2 = double.Parse(Console.ReadLine());
        Console.Write("Nhập cạnh 3 tam giác: ");
        canh3 = double.Parse(Console.ReadLine());
    }

    public override double TinhChuVi()
    {
        return canh1 + canh2 + canh3;
    }

    public override double TinhDienTich()
    {
        // Sử dụng công thức Heron
        double p = TinhChuVi() / 2; // Nửa chu vi
        return Math.Sqrt(p * (p - canh1) * (p - canh2) * (p - canh3));
    }

    public override string ToString()
    {
        return $"Hình tam giác (cạnh = {canh1}, {canh2}, {canh3})";
    }
}

class HinhChuNhat : Hinh
{
    private double chieuDai, chieuRong;

    public override void Nhap()
    {
        Console.Write("Nhập chiều dài hình chữ nhật: ");
        chieuDai = double.Parse(Console.ReadLine());
        Console.Write("Nhập chiều rộng hình chữ nhật: ");
        chieuRong = double.Parse(Console.ReadLine());
    }

    public override double TinhChuVi()
    {
        return 2 * (chieuDai + chieuRong);
    }

    public override double TinhDienTich()
    {
        return chieuDai * chieuRong;
    }

    public override string ToString()
    {
        return $"Hình chữ nhật (dài = {chieuDai}, rộng = {chieuRong})";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        List<Hinh> danhSachHinh = new List<Hinh>();

        Console.Write("Nhập số lượng hình: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhập thông tin hình thứ {i + 1}:");
            Console.Write("Chọn loại hình (1-Tròn, 2-Vuông, 3-Tam giác, 4-Chữ nhật): ");
            int loai = int.Parse(Console.ReadLine());

            Hinh hinh;
            switch (loai)
            {
                case 1:
                    hinh = new HinhTron();
                    break;
                case 2:
                    hinh = new HinhVuong();
                    break;
                case 3:
                    hinh = new HinhTamGiac();
                    break;
                case 4:
                    hinh = new HinhChuNhat();
                    break;
                default:
                    Console.WriteLine("Loại hình không hợp lệ, chọn lại.");
                    i--;
                    continue;
            }

            hinh.Nhap();
            danhSachHinh.Add(hinh);
        }

        double tongChuVi = 0;
        double tongDienTich = 0;

        Console.WriteLine("\nKết quả:");
        for (int i = 0; i < danhSachHinh.Count; i++)
        {
            var hinh = danhSachHinh[i];
            double chuVi = hinh.TinhChuVi();
            double dienTich = hinh.TinhDienTich();
            tongChuVi += chuVi;
            tongDienTich += dienTich;
            Console.WriteLine($"{hinh}: Chu vi = {chuVi:F2}, Diện tích = {dienTich:F2}");
        }

        Console.WriteLine($"\nTổng chu vi tất cả hình: {tongChuVi:F2}");
        Console.WriteLine($"Tổng diện tích tất cả hình: {tongDienTich:F2}");
    }
}