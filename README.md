# 🎯 Website xem lịch thi đấu bóng đá
Dự án xây dựng website xem lịch thi đấu thể thao được thiết kế nhằm cung cấp cho người dùng một nền tảng xem lịch thể thao cùng với kết quả trận đấu trực tuyến của bộ môn bóng đá một cách chính xác nhất.
# 🚀 Các tính năng đạt được của dự án
- Xem lịch thi đấu theo thời gian
- Xem lịch thi đấu theo giải đấu
- Tìm kiếm giải đáu, trận đấu
- Xem thống kê của trận đấu
- Đăng nhập, đăng ký
- Xác thực và phân quyền
- Đăng, sửa, xóa bài viết
- Bình luận bài viết
- Tham gia minigame dự đoán tỷ số
- Hẹn lịch nhắc nhở trận đấu
- Trang quản trị Admin quản lý như (người dùng, vai trò, quyền hạn, trận đấu, giải đấu, mùa giải ...)
# 🛠️ Các công nghệ sử dụng
- **Backend:** ASP.NET Core, Entity Framework Core, LINQ
- **Frontend:** ReactJS, Bootstrap
- **Database:** PostgreSQL
- **Authentication:** JWT
# ⚙️ Hướng dẫn cài đặt
1. Clone dự án
   https://github.com/thanhdanhk2004/SportsSchedule.git
2. Cài đặt các gói trong Backend
   - BCrypt.Net-Next(4.0.3) (gói này dừng để hashing mật khẩu theo thuật toán bcrypt)
   - Microsoft.AspNetCore.Authentication.JwtBearer(8.0.0) (gói này giúp sử dụng JWT để xác thực và phân quyền)
   - Microsoft.EntityFrameworkCore(9.0.0) (Gói này để sử dụng Entity Framwork Core)
   - Microsoft.EntityFrameworkCore.Tools(9.0.0) (Gói này hỗ trợ cho Entity Framework Core)
   - Newtonsoft.Json (13.0.3) (Gói này dùng để xử lý JSON)
   - Npgsql.EntityFrameworkCore.PostgreSQL (9.0.1 (Gói này để làm việc với Postgre SQL)
3 Cài đặt Fronted
- npm install
- npm install bootstrap react-bootstrap
- npm start
# 🔮 Tương lai phát triển của dự án
- Thêm một số giải đấu thế giới (World Cup, Euro ...)
- Thêm một trang thương mại điện tử nhỏ bán các sán phẩm liên quan đến thể thao
- Phân tích dữ liệu đưa ra được dự đoán tỷ lệ thắng cho các trận đấu sắp diễn ra
# 👨‍💻 Tác giả: Lê Thanh Dân
- 📧 Email: thanhdanhk2004@gmail.com
- 💼 LinkedIn: https://www.linkedin.com/in/d%C3%A2n-l%C3%AA-thanh-77b229361/
