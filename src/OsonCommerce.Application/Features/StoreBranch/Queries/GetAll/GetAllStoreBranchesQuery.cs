using MediatR;
using System.Collections.Generic;

namespace OsonCommerce.Application.Features;

public class GetAllStoreBranchesQuery : IRequest<List<StoreBranchDto>>
{
} 