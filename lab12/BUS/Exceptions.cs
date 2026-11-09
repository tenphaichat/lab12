using System;

namespace Lab12_MasterDetail_Transaction.BUS
{
    // Ngoại lệ kiểm tra tính hợp lệ dữ liệu đầu vào (Validation Error)
    public class ValidationException : Exception
    {
        public string PropertyName { get; }

        public ValidationException(string message, string propertyName = "") 
            : base(message)
        {
            PropertyName = propertyName;
        }
    }

    // Ngoại lệ vi phạm quy tắc nghiệp vụ hoặc lỗi từ CSDL (Business Rule Error)
    public class BusinessException : Exception
    {
        public int ErrorCode { get; }

        public BusinessException(int errorCode, string message, Exception innerException = null) 
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

        public BusinessException(string message, int errorCode = 0, Exception innerException = null) 
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }

    // Ngoại lệ xung đột cập nhật đồng thời (Optimistic Concurrency Conflict - Bài 9)
    public class OptimisticConcurrencyException : Exception
    {
        public string EntityKey { get; }

        public OptimisticConcurrencyException(string entityKey, string message = "Dữ liệu đã bị người dùng khác sửa đổi hoặc xóa.") 
            : base(message)
        {
            EntityKey = entityKey;
        }
    }

    // Thực thể ghi log kiểm thử và giám sát lỗi
    public class ErrorLogItem
    {
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string ErrorType { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string StackTrace { get; set; }

        public override string ToString()
        {
            return $"[{Timestamp:HH:mm:ss}] [{ErrorType}] {Message}";
        }
    }
}
