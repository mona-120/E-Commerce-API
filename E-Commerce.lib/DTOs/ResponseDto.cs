using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.lib.DTOs
{
    public class ResponseDto
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public ResponseDto(bool success, string? message)
        {
            Success = success;
            Message = message;
        }
    }
}
