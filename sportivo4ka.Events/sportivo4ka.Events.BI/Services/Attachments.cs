using AutoMapper;
using System;
using System.IO;
using System.Web;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sportivo4ka.Events.BI.Interfaces;
using sportivo4ka.Events.BI.Options;
using sportivo4ka.Events.Data.Dto;
using sportivo4ka.Events.EF;
using Microsoft.EntityFrameworkCore;
using sportivo4ka.Events.Data.Entity;
using sportivo4ka.Events.General.Expansions;
using System.Text.Json;

namespace sportivo4ka.Events.BI.Services
{
    public class Attachment : IAttachment
    {
        private readonly AttachmentConfig _config;
        private readonly ServiceDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDataSend _dataSend;

        public Attachment(IMapper mapper, ServiceDbContext context, AttachmentConfig config, IDataSend dataSend)
        {
            _mapper = mapper;
            _context = context;
            _config = config;
            _dataSend = dataSend;
        }

        public async Task<string> Upload(AttachmentDto attachment)
        {
            return await _dataSend.PostFileWithStringContent(
                (attachment.Stream, attachment.FileName),
                _config.AttachmentService.Url,
                _config.AttachmentService.Token
                );
        }
    }
}