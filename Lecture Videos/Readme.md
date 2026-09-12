# MyFirstCleanArchitectureBlazorApp

## Mô tả

Dự án này là một ứng dụng Blazor Server-side được xây dựng theo các nguyên tắc của Kiến trúc Sạch (Clean Architecture). Nó minh họa cách tách biệt các mối quan tâm (separation of concerns) thành các lớp riêng biệt: Lớp Nghiệp vụ Cốt lõi (CoreBusiness), Lớp Trường hợp Sử dụng (UseCase), Lớp Lưu trữ Dữ liệu (DataStore), và Lớp Trình bày (Presentation - MyFirstBlazorApp). Ứng dụng này là một ví dụ eShop đơn giản, tập trung vào việc hiển thị sản phẩm từ một nguồn dữ liệu được mã hóa cứng (hard-coded).

## Cấu trúc Thư mục Dự án (Chi tiết)

Dưới đây là cấu trúc thư mục chi tiết của dự án, bao gồm các tệp mã nguồn và các tệp cấu hình quan trọng. Nội dung của các thư mục `bin` (chứa kết quả biên dịch) và `obj` (chứa các tệp trung gian trong quá trình biên dịch) được tóm tắt để ngắn gọn nhưng vẫn thể hiện sự tồn tại của chúng.

```text
MyFirstCleanArchitectureBlazorApp/
├── eShop.CoreBusiness/              -- Chứa các Entities và logic nghiệp vụ cốt lõi.
│   ├── Models/
│   │   └── Product.cs             -- Model cho sản phẩm.
│   └── eShop.CoreBusiness.csproj
├── eShop.DataStore.HardCoded/       -- Triển khai truy cập dữ liệu (dữ liệu hard-coded).
│   ├── ProductRepository.cs       -- Triển khai IProductRepository.
│   └── eShop.DataStore.HardCoded.csproj
├── eShop.UseCase/                   -- Chứa các kịch bản nghiệp vụ (Use Cases).
│   ├── PluginInterfaces/
│   │   └── DateStore/             -- Interfaces cho DataStore.
│   │       └── IProductRepository.cs -- Interface cho kho lưu trữ sản phẩm.
│   ├── SearchProductScreen/
│   │   ├── ISearchProduct.cs      -- Interface cho Use Case tìm kiếm sản phẩm.
│   │   ├── IViewProduct.cs        -- Interface cho Use Case xem sản phẩm.
│   │   ├── SearchProduct.cs       -- Triển khai Use Case tìm kiếm.
│   │   └── ViewProduct.cs         -- Triển khai Use Case xem sản phẩm.
│   └── eShop.UseCase.csproj
├── MyFirstBlazorApp/                -- Lớp Presentation (Ứng dụng Blazor Server).
│   ├── Data/                      -- Dữ liệu mẫu (WeatherForecast).
│   │   ├── WeatherForecast.cs
│   │   └── WeatherForecastService.cs
│   ├── Pages/                     -- Các trang Blazor (components có thể điều hướng).
│   │   ├── Error.cshtml
│   │   ├── Error.cshtml.cs
│   │   ├── Index.razor
│   │   ├── _Host.cshtml
│   │   └── _Layout.cshtml
│   ├── Properties/
│   │   └── launchSettings.json    -- Cấu hình khởi chạy.
│   ├── Shared/                    -- Các Blazor components dùng chung.
│   │   ├── MainLayout.razor
│   │   ├── MainLayout.razor.css
│   │   ├── NavMenu.razor
│   │   ├── NavMenu.razor.css
│   │   └── SurveyPrompt.razor
│   ├── wwwroot/                   -- Tài nguyên tĩnh (CSS, JS, images).
│   │   ├── css/
│   │   │   ├── bootstrap/
│   │   │   ├── open-iconic/
│   │   │   └── site.css
│   │   └── favicon.ico
│   ├── appsettings.Development.json
│   ├── appsettings.json
│   ├── MyFirstBlazorApp.csproj
│   ├── Program.cs                 -- Điểm vào chính, cấu hình services.
│   └── _Imports.razor             -- Khai báo namespace chung cho Razor.
├── MyFirstCleanArchitectureBlazorApp.sln -- Tệp Solution.
└── README.md                        -- Tệp này.
```

**Lưu ý cho sinh viên:**
* Thư mục `.vs/` được Visual Studio tự động tạo ra để lưu các cài đặt riêng của người dùng cho solution đó. Nó thường không được đưa vào hệ thống quản lý phiên bản (ví dụ: Git).
* Các thư mục `bin/` và `obj/` chứa kết quả biên dịch và các tệp trung gian trong quá trình build. Số lượng tệp trong này rất nhiều và thường không được các lập trình viên chỉnh sửa trực tiếp. Cấu trúc trên chỉ liệt kê một số tệp chính để bạn hình dung.
* Các tệp `.csproj` là tệp dự án, chứa thông tin về các tệp mã nguồn, các gói NuGet phụ thuộc, và cấu hình build cho từng project.
* Tệp `.sln` là tệp solution, dùng để nhóm các project liên quan lại với nhau.

## Cách chạy dự án

1.  **Yêu cầu:** Đảm bảo bạn đã cài đặt .NET 6 SDK. (Bạn có thể tải từ [trang web chính thức của Microsoft .NET](https://dotnet.microsoft.com/download/dotnet/6.0)).
2.  **Mở Terminal/Command Prompt:**
    * Trên Windows, bạn có thể dùng Command Prompt, PowerShell, hoặc Windows Terminal.
    * Trên macOS hoặc Linux, bạn có thể dùng Terminal.
3.  **Di chuyển đến thư mục gốc của solution:**
    ```bash
    cd Path\To\Your\MyFirstCleanArchitectureBlazorApp
    ```
    (Thay `Path\To\Your\` bằng đường dẫn thực tế đến thư mục dự án của bạn).
4.  **Di chuyển vào thư mục dự án Blazor App:**
    ```bash
    cd MyFirstBlazorApp
    ```
5.  **Chạy ứng dụng:**
    ```bash
    dotnet run
    ```
    Lệnh này sẽ build và chạy ứng dụng. Bạn sẽ thấy output trong terminal cho biết ứng dụng đang lắng nghe trên các URL nào đó (ví dụ: `http://localhost:5124` và `https://localhost:7124`).
6.  **Mở trình duyệt web:**
    Mở trình duyệt (Chrome, Firefox, Edge, Safari,...) và truy cập vào một trong các địa chỉ URL được hiển thị ở bước trên (thường là địa chỉ HTTPS, ví dụ: `https://localhost:7124`).

## Công nghệ sử dụng

* **.NET 6:** Nền tảng phát triển ứng dụng của Microsoft.
* **Blazor Server-side:** Một framework để xây dựng giao diện người dùng web tương tác bằng C# thay vì JavaScript. Với Blazor Server, UI được cập nhật thông qua kết nối SignalR.
* **C#:** Ngôn ngữ lập trình chính được sử dụng.
* **Kiến trúc Sạch (Clean Architecture):** Một tập hợp các nguyên tắc thiết kế phần mềm để tạo ra các hệ thống dễ hiểu, dễ bảo trì, dễ kiểm thử và linh hoạt.

## Kiến trúc (Dành cho sinh viên)

Dự án này tuân theo các nguyên tắc của **Kiến trúc Sạch (Clean Architecture)**. Mục tiêu chính là tạo ra một hệ thống mà các phần khác nhau của nó (như giao diện người dùng, logic nghiệp vụ, truy cập dữ liệu) được tách biệt rõ ràng. Điều này mang lại nhiều lợi ích:

* **Dễ bảo trì:** Khi một phần thay đổi, các phần khác ít bị ảnh hưởng.
* **Dễ kiểm thử (Testable):** Có thể kiểm thử logic nghiệp vụ một cách độc lập mà không cần đến giao diện hay cơ sở dữ liệu.
* **Linh hoạt:** Dễ dàng thay thế một công nghệ này bằng một công nghệ khác (ví dụ: thay đổi cơ sở dữ liệu, hoặc thậm chí là framework giao diện người dùng) mà ít ảnh hưởng đến phần còn lại.

### Các Lớp Chính trong Kiến trúc Sạch của Dự án này:

1.  **`eShop.CoreBusiness` (Lõi Nghiệp Vụ - Entities & Core Business Logic):**
    * **Vai trò:** Đây là lớp trong cùng và quan trọng nhất. Nó chứa các **Entities** (các đối tượng nghiệp vụ cốt lõi như `Product`) và các quy tắc nghiệp vụ chung nhất, không phụ thuộc vào bất kỳ chi tiết kỹ thuật nào của ứng dụng (như cơ sở dữ liệu hay giao diện).
    * **Đặc điểm:** Lớp này không "biết" gì về các lớp bên ngoài nó. Nó không tham chiếu đến `eShop.UseCase`, `eShop.DataStore.HardCoded`, hay `MyFirstBlazorApp`.
    * **Ví dụ:** Lớp `Product.cs` định nghĩa một sản phẩm là gì, có những thuộc tính nào.

2.  **`eShop.UseCase` (Các Trường Hợp Sử Dụng - Application Business Rules):**
    * **Vai trò:** Lớp này chứa logic nghiệp vụ cụ thể cho từng hành động mà người dùng có thể thực hiện với hệ thống (ví dụ: "Tìm kiếm sản phẩm", "Xem chi tiết sản phẩm"). Nó điều phối luồng dữ liệu giữa lớp Trình bày (UI) và lớp Lưu trữ Dữ liệu (DataStore).
    * **Phụ thuộc:** Lớp này phụ thuộc vào `eShop.CoreBusiness` (để sử dụng các Entities).
    * **Interfaces (PluginInterfaces):** Một điểm quan trọng là lớp UseCase định nghĩa các **Interfaces** (ví dụ: `IProductRepository`) cho việc truy cập dữ liệu. Lớp UseCase không quan tâm việc dữ liệu được lấy từ đâu (SQL Server, file text, hay dữ liệu mã hóa cứng), nó chỉ cần một "ai đó" triển khai các interface này.
    * **Ví dụ:** `SearchProduct.cs` nhận yêu cầu tìm kiếm từ UI, sau đó sử dụng `IProductRepository` để lấy danh sách sản phẩm phù hợp, và trả kết quả về cho UI.

3.  **`eShop.DataStore.HardCoded` (Lưu Trữ Dữ Liệu - Interface Adapters for Data):**
    * **Vai trò:** Lớp này chịu trách nhiệm triển khai các interface được định nghĩa trong lớp `eShop.UseCase` (cụ thể là `IProductRepository`). Nó là cầu nối giữa logic nghiệp vụ và nguồn dữ liệu thực tế. Trong dự án này, dữ liệu được "mã hóa cứng" (hard-coded) ngay trong code, nhưng trong một ứng dụng thực tế, lớp này có thể tương tác với SQL Server, MySQL, MongoDB, hoặc một API bên ngoài.
    * **Phụ thuộc:** Lớp này phụ thuộc vào `eShop.UseCase` (để biết nó cần triển khai interface nào) và có thể phụ thuộc vào `eShop.CoreBusiness` (để làm việc với các đối tượng Product).
    * **Ví dụ:** `ProductRepository.cs` triển khai các phương thức `GetProduct()` và `GetProducts()` của `IProductRepository` bằng cách trả về một danh sách sản phẩm được tạo sẵn.

4.  **`MyFirstBlazorApp` (Trình Bày - Frameworks & Drivers & UI):**
    * **Vai trò:** Đây là lớp ngoài cùng, chịu trách nhiệm hiển thị giao diện người dùng (UI) và nhận tương tác từ người dùng. Nó sử dụng Blazor Server framework.
    * **Phụ thuộc:** Lớp này phụ thuộc vào `eShop.UseCase` để thực hiện các hành động nghiệp vụ. Nó không bao giờ được phép truy cập trực tiếp vào `eShop.DataStore.HardCoded` hay `eShop.CoreBusiness`.
    * **Ví dụ:** Một trang Blazor (ví dụ: `Index.razor`) khi người dùng nhấn nút tìm kiếm, nó sẽ gọi một phương thức trong một UseCase (ví dụ: `ISearchProduct.Execute()`) để lấy dữ liệu và hiển thị lên màn hình.

### Quy tắc Phụ thuộc (The Dependency Rule):

Đây là quy tắc quan trọng nhất trong Clean Architecture: **Mọi sự phụ thuộc về mã nguồn chỉ được hướng vào trong.**

* Các lớp bên ngoài (như `MyFirstBlazorApp`, `eShop.DataStore.HardCoded`) phụ thuộc vào các lớp bên trong (`eShop.UseCase`).
* Lớp `eShop.UseCase` phụ thuộc vào lớp trong cùng là `eShop.CoreBusiness`.
* Lớp `eShop.CoreBusiness` không phụ thuộc vào bất kỳ lớp nào khác.

Điều này giúp cho:
* **Logic nghiệp vụ cốt lõi (`eShop.CoreBusiness`, `eShop.UseCase`)** không bị ảnh hưởng bởi những thay đổi ở các lớp bên ngoài như giao diện người dùng hay công nghệ lưu trữ dữ liệu.
* Bạn có thể thay đổi cách hiển thị (ví dụ: từ Blazor Server sang Blazor WebAssembly, hoặc thậm chí là một ứng dụng di động) mà không cần sửa đổi nhiều ở `eShop.UseCase` hay `eShop.CoreBusiness`.
* Bạn có thể thay đổi nguồn dữ liệu (ví dụ: từ dữ liệu hard-coded sang SQL Server) bằng cách tạo một project DataStore mới triển khai cùng các interface mà không ảnh hưởng đến các lớp khác.

Kiến trúc này đòi hỏi sự kỷ luật trong việc thiết kế và quản lý các mối phụ thuộc, nhưng mang lại lợi ích lớn về lâu dài cho các dự án phần mềm.