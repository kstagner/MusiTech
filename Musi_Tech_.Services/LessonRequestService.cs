using Musi_Tech_.Data;
using Musi_Tech_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musi_Tech_.Services
{
    public class LessonRequestService
    {
        private readonly Guid _userId;

        public LessonRequestService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLessonRequest(LessonRequestCreate model)
        {
            var entity =
                new LessonRequest()
                {
                    OwnerID = _userId,
                    CustomerFullName = model.CustomerFullName,
                    Instrument = model.Instrument,
                    RequestedStartDate = model.RequestStartDate,
                    ZipCode = model.ZipCode
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.LessonRequests.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LessonRequestListItem> GetLessonRequests()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .LessonRequests
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new LessonRequestListItem
                                {
                                    LessonRequestID = e.LessonRequestID,
                                    CustomerFullName = e.CustomerFullName,
                                    Instrument = e.Instrument,

                                }
                        );

                return query.ToArray();
            }
        }

        public LessonRequestDetail GetLessonRequestByID(int lessonrequestID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .LessonRequests
                        .Single(e => e.LessonRequestID == lessonrequestID && e.OwnerID == _userId);
                return
                    new LessonRequestDetail
                    {
                        LessonRequestID = entity.LessonRequestID,
                        CustomerFullName = entity.CustomerFullName,
                        Instrument = entity.Instrument,
                        RequestedStartDate = entity.RequestedStartDate,
                        ZipCode = entity.ZipCode
                    };
            }
        }

        public bool UpdateLessonRequest(LessonRequestEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .LessonRequests
                        .Single(e => e.LessonRequestID == model.LessonRequestID && e.OwnerID == _userId);

                entity.CustomerFullName = model.CustomerFullName;
                entity.Instrument = model.Instrument;
                entity.RequestedStartDate = model.RequestStartDate;
                entity.ZipCode = model.ZipCode;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLessonRequest(int lessonrequestID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .LessonRequests
                        .Single(e => e.LessonRequestID == lessonrequestID && e.OwnerID == _userId);

                ctx.LessonRequests.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
