using System;
using System.Collections; 
using System.Collections.Generic; 

class PhanSo
{
    private int tuSo; // Tử số
    private int mauSo; // Mẫu số

    public PhanSo(int tuSo = 0, int mauSo = 1)
    {
        this.tuSo = tuSo;
        this.mauSo = mauSo != 0 ? mauSo : 1; // Đảm bảo mẫu số không bằng 0
    }

    // Hàm nhập phân số từ người dùng
    public void NhapPhanSo()
    {
        Console.Write("Nhập tử số: ");
        tuSo = int.Parse(Console.ReadLine());

        while (true)
        {
            Console.Write("Nhập mẫu số: ");
            mauSo = int.Parse(Console.ReadLine());
            if (mauSo != 0)
                break;
            Console.WriteLine("Mẫu số không thể bằng 0. Vui lòng nhập lại.");
        }
    }

    // Hiển thị phân số dạng tử/mẫu
    public override string ToString()
    {
        return $"{tuSo}/{mauSo}";
    }

    // Hàm cộng hai phân số
    public PhanSo Cong(PhanSo other)
    {
        int tuMoi = this.tuSo * other.mauSo + other.tuSo * this.mauSo;
        int mauMoi = this.mauSo * other.mauSo;
        return new PhanSo(tuMoi, mauMoi);
    }

    // Hàm tối giản phân số
    public void ToiGian()
    {
        int ucln = UCLN(Math.Abs(tuSo), Math.Abs(mauSo));
        tuSo /= ucln;
        mauSo /= ucln;
    }

    // Hàm tìm ước chung lớn nhất (UCLN)
    private int UCLN(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}

class Program
{
    // Tính tổng phân số dùng ArrayList 
    static PhanSo TinhTongPhanSoArrayList(ArrayList danhSach)
    {
        if (danhSach.Count == 0)
            return new PhanSo(0, 1);

        PhanSo tong = (PhanSo)danhSach[0]; // Phải ép kiểu 
        for (int i = 1; i < danhSach.Count; i++)
        {
            tong = tong.Cong((PhanSo)danhSach[i]); // Ép kiểu mỗi phần tử
        }
        tong.ToiGian();
        return tong;
    }

    // Tính tổng phân số dùng List<PhanSo> (Generic Collection)
    static PhanSo TinhTongPhanSoList(List<PhanSo> danhSach)
    {
        if (danhSach.Count == 0)
            return new PhanSo(0, 1);

        PhanSo tong = danhSach[0]; // Không cần ép kiểu
        for (int i = 1; i < danhSach.Count; i++)
        {
            tong = tong.Cong(danhSach[i]); // Truy cập an toàn kiểu
        }
        tong.ToiGian();
        return tong;
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Hỗ trợ tiếng Việt

        // Khởi tạo ArrayList (không generic) và List<PhanSo> (generic)
        ArrayList danhSachArrayList = new ArrayList();
        List<PhanSo> danhSachList = new List<PhanSo>();

        // Nhập số lượng phân số
        Console.Write("Nhập số lượng phân số: ");
        int n = int.Parse(Console.ReadLine());

        // Nhập từng phân số
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhập phân số thứ {i + 1}:");
            PhanSo ps = new PhanSo();
            ps.NhapPhanSo();
            danhSachArrayList.Add(ps); // ArrayList chấp nhận mọi kiểu
            danhSachList.Add(ps);      // List<PhanSo> chỉ nhận PhanSo
        }

        // Tính và hiển thị tổng dùng ArrayList
        Console.WriteLine("\nTổng các phân số (sử dụng ArrayList):");
        PhanSo tongArrayList = TinhTongPhanSoArrayList(danhSachArrayList);
        Console.WriteLine(tongArrayList);

        // Tính và hiển thị tổng dùng List<PhanSo>
        Console.WriteLine("Tổng các phân số (sử dụng List<PhanSo>):");
        PhanSo tongList = TinhTongPhanSoList(danhSachList);
        Console.WriteLine(tongList);
    }
}