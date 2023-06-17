﻿using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class JobPostingServices : RepositoryBase<JobPosting>
    {
        public JobPostingServices(CandidateManagementContext context) : base(context)
        {
        }
    }
}
